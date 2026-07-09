
"use client"

import React from 'react';
import "../globals.css";
import { Slot } from "@/app/Models/Slot";   
import { Button } from 'antd';
import {
    updateTimeslot, TimeSlotUpdateRequest,
    createBooking, BookingCreateRequest, DoctorSheduleProps
} from "@/app/Services/service";
import { useState, useEffect } from "react";  



export default function TimeslotsButtons({ setNumbers, slots }: DoctorSheduleProps) {
    const [currentUserRole, setCurrentUserRole] = useState("");
    const [currentUserId, setCurrentUserId] = useState("");

    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        setCurrentUserRole(role);
        const id = localStorage.getItem("id") || "";
        setCurrentUserId(id);
    }, []);


    const sortedSlots = [...slots].sort((a, b) => {
        return a.datetimeStart.localeCompare(b.datetimeStart);
    });

    const data = Object.keys(sortedSlots).map((slot, index) => ({
        key: index,
        id: sortedSlots[index].id,
        datetimeStart: sortedSlots[index].datetimeStart,
        datetimeStop: sortedSlots[index].datetimeStop,
        label: sortedSlots[index].datetimeStart.split(" ")[1] + " - " + sortedSlots[index].datetimeStop.split(" ")[1],
        isBooked: sortedSlots[index].isBooked,
        doctorId: sortedSlots[index].doctorId,
        patientId: sortedSlots[index].patientId
    }));

    const timeslotRequest: TimeSlotUpdateRequest = {
        patientid: '',
        slotid: '',
        isbooked: false
    };

    const bookingRequest: BookingCreateRequest = {
        slotid: "",
        patientid: "",
        doctorid: "",
        doctorusername: "",
        isbooked: false
    };


    const handleClick = (value: Slot) => {
        if (currentUserRole == 'patient') {
            if (!value.isBooked) {
                timeslotRequest.slotid = value.id;
                timeslotRequest.patientid = currentUserId;
                timeslotRequest.isbooked = true;
                bookingRequest.slotid = value.id;
                bookingRequest.patientid = currentUserId;
                bookingRequest.doctorid = value.doctorId;
                bookingRequest.isbooked = true;
                updateTimeslot(timeslotRequest);
                createBooking(bookingRequest);
                setNumbers((oldNumbers: number[]) => [...oldNumbers, 1]);
            }
        }
    };

    return (
        <div>
            <div
                style={{
                    display: 'grid',
                    gridTemplateColumns: 'repeat(5, 1fr)',
                    gap: '10px',
                    maxWidth: '800px' 
                }}
            >
                {data.map((s) => (
                    <Button
                        key={s.id}
                        onClick={() => handleClick(s)}
                        color={(!s.isBooked) ? "primary" : "danger"}
                        variant="solid"
                        style={{
                            width: '100%', 
                            height: '40px'
                        }}
                    >
                        {s.label}
                    </Button>
                ))}
                </div>
            </div>
    );
}

