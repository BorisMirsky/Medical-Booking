///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { getAppointmentsByPatientId, TableDataType } from "@/app/Services/service";
import { Appointment } from "@/app/Models/Appointment";
import { Table, Space } from "antd";
import { useEffect, useState } from "react";
import "@/app/globals.css";
import Title from "antd/es/typography/Title";




export default function PatientMyAppointments() {
    const [, setCurrentUserId] = useState("");
    const [apps, setApps] = useState<Appointment[]>([]);

    useEffect(() => {
        const id = localStorage.getItem("id") || "";
        setCurrentUserId(id);
        setApps([]);
        const getApps = async () => {
            const response = await getAppointmentsByPatientId(id);
            if (Array.isArray(response)) {
                setApps(response);
            } else {
                setApps([]);
            }
        };
        getApps();
    }, []);


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
            dataIndex: 'doctorusername',
            key: 'doctorusername',
        },
        {
            title: 'Специализация врача',
            dataIndex: 'doctorspeciality',
            key: 'doctorspeciality',
        },
        {
            title: 'Начало приёма',
            dataIndex: 'date',
            key: 'date',
            sorter: (a: TableDataType, b: TableDataType) => {
                const dateA = normalizeDate(a.timeslotDatetimeStart);
                const dateB = normalizeDate(b.timeslotDatetimeStart);
                return dateA.localeCompare(dateB);
            },
            defaultSortOrder: 'descend' as const,
            render: (text: string, record: TableDataType) => {
                const normalized = normalizeDate(record.timeslotDatetimeStart);
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
                return record.date;
            }
        },
    ];

    const data: TableDataType[] = apps.map((app: Appointment, index: number) => ({
        key: index,
        n: (index + 1),
        doctorusername: app.doctorUserName || 'Не указан',
        doctorspeciality: app.patientUserName || 'Не указана',
        date: app.timeslotDatetimeStart || '',
        timeslotDatetimeStart: app.timeslotDatetimeStart || ''
    }));

    return (
        <div>
            <Space
                direction="vertical"
                size="large"
                style={{ margin: '2rem', width: '50%' }}
            >
                <Title level={2}>Мои посещения врачей</Title>
            </Space>
            <div>
                <Table<TableDataType>
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