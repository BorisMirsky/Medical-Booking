"use client"

import React from 'react';
import {
    getBookingsByPatient, updateTimeslot, TimeSlotUpdateRequest,
    BookingCreateRequest, createBooking, TableBookingDataType
} from "@/app/Services/service";
import { Booking } from "@/app/Models/Booking";
import { Table, Button, Space } from "antd";
import { useEffect, useState } from "react";
import "@/app/globals.css";
import Title from "antd/es/typography/Title";




export default function PatientBookings() {
    const [currentUserId, setCurrentUserId] = useState("");
    const [bookings, setBookings] = useState<Booking[]>([]);

    const normalizeDate = (dateStr: string): string => {
        if (!dateStr) return '';

        const parts = dateStr.split(' ');
        const dateParts = parts[0].split('-');
        const time = parts[1] || '';

        if (dateParts.length === 3 && dateParts[1].length === 2 && dateParts[2].length === 2) {
            const year = dateParts[0];
            const day = dateParts[1];
            const month = dateParts[2];
            return `${year}-${month}-${day} ${time}`;
        }

        return dateStr;
    };

    const columns = [
        {
            title: 'Врач',
            dataIndex: 'username',
            key: 'username',
        },
        {
            title: 'Специальность',
            dataIndex: 'speciality',
            key: 'speciality',
        },
        {
            title: 'Статус записи',
            dataIndex: 'isBooked',
            key: 'isBooked',
        },
        {
            title: 'Начало приёма',
            dataIndex: 'timeslotStart',
            key: 'timeslotStart',
            sorter: (a: TableBookingDataType, b: TableBookingDataType) => {
                const dateA = normalizeDate(a.timeslotStart);
                const dateB = normalizeDate(b.timeslotStart);
                return dateA.localeCompare(dateB);
            },
            defaultSortOrder: 'descend' as const,
            render: (text: string, record: TableBookingDataType) => {
                const normalized = normalizeDate(record.timeslotStart);
                try {
                    const date = new Date(normalized);
                    if (!isNaN(date.getTime())) {
                        return date.toLocaleString('ru-RU', {
                            day: '2-digit',
                            month: '2-digit',
                            year: 'numeric',
                            hour: '2-digit',
                            minute: '2-digit'
                        });
                    }
                } catch (e) {
                    console.error("Ошибка при преобразовании даты:", e);
                }
                return record.timeslotStart;
            }
        },
        {
            title: 'Конец приёма',
            dataIndex: 'timeslotStop',
            key: 'timeslotStop',
            render: (text: string, record: TableBookingDataType) => {
                const normalized = normalizeDate(record.timeslotStop);
                try {
                    const date = new Date(normalized);
                    if (!isNaN(date.getTime())) {
                        return date.toLocaleString('ru-RU', {
                            day: '2-digit',
                            month: '2-digit',
                            year: 'numeric',
                            hour: '2-digit',
                            minute: '2-digit'
                        });
                    }
                } catch (e) {
                    console.error("Ошибка при преобразовании даты:", e);
                }
                return record.timeslotStop;
            }
        },
        {
            title: 'Отмена',
            dataIndex: 'cancel',
            key: 'cancel',
            render: (text: string, record: TableBookingDataType) => (
                <Button
                    onClick={() => cancelBooking(record.key)}
                    disabled={
                        !bookings[record.key]?.isBooked ||
                        bookings[record.key]?.isClosed
                    }
                >
                    {"Отмена"}
                </Button>
            ),
        }
    ];

    useEffect(() => {
        const id = localStorage.getItem("id") || "";
        setCurrentUserId(id);
        setBookings([]);
        const getBookings = async () => {
            const response = await getBookingsByPatient(id);
            if (Array.isArray(response)) {
                setBookings(response);
            } else {
                setBookings([]);
            }
        };
        getBookings();
    }, []);

    const data: TableBookingDataType[] = bookings.map((booking: Booking, index: number) => ({
        key: index,
        n: (index + 1),
        username: booking.doctorSpeciality || 'Не указан',
        speciality: booking.doctorUserName || 'Не указана',
        timeslotId: booking.timeslotId || '',
        isBooked: booking.isClosed
            ? "Приём состоялся"
            : booking.isBooked
                ? "Вы записаны"
                : "Запись отменена",
        timeslotStart: booking.timeslotDatetimeStart || '',
        timeslotStop: booking.timeslotDatetimeStop || '',
        cancel: ""
    }));

    const cancelBooking = async (key: number) => {
        if (!bookings[key]) return;

        const booking = bookings[key];
        const timeslotRequest: TimeSlotUpdateRequest = {
            slotid: booking.timeslotId,
            patientid: currentUserId,
            isbooked: false
        };

        const bookingRequest: BookingCreateRequest = {
            slotid: booking.timeslotId,
            patientid: currentUserId,
            doctorid: booking.doctorId,
            doctorusername: booking.doctorUserName,
            isbooked: false,
        };

        try {
            await updateTimeslot(timeslotRequest);
            await createBooking(bookingRequest);

            // Обновляем состояние после отмены
            const updatedBookings = bookings.map((b, index) =>
                index === key ? { ...b, isBooked: false } : b
            );
            setBookings(updatedBookings);
        } catch (error) {
            console.error("Ошибка при отмене записи:", error);
        }
    };

    return (
        <div>
            <Space
                direction="vertical"
                size="large"
                style={{ margin: '2rem', width: '50%' }}
            >
                <Title level={2}>Мои записи к врачам (бронирования)</Title>
            </Space>
            <div>
                <Table<TableBookingDataType>
                    dataSource={data}
                    columns={columns}
                    pagination={false}
                    footer={() => ""}
                    bordered
                />
            </div>
        </div>
    );
}