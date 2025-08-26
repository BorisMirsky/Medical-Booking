
"use client"

import React from 'react';
import "../globals.css";
import { Slot } from "@/app/Models/Slot";   
import { Button, Space } from 'antd';
import {
    updateTimeslot, TimeSlotUpdateRequest,
    createBooking, BookingCreateRequest, DoctorSheduleProps
} from "@/app/Services/service";
import { useState, useEffect } from "react";  




export default function TimeslotsButtons({ numbers, setNumbers, slots }: DoctorSheduleProps) {
    const [currentUserRole, setCurrentUserRole] = useState("");
    const [currentUserId, setCurrentUserId] = useState("");
    //const data1 = Object.keys(slots).map((slot, index) => ({
    //    isBooked: slots[index].isBooked,
    //}));

    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        setCurrentUserRole(role);
        const id = localStorage.getItem("id") || "";
        setCurrentUserId(id);
    }, []);


    const data = Object.keys(slots).map((slot, index) => ({
        key: index,
        id: slots[index].id,
        datetimeStart: slots[index].datetimeStart,
        datetimeStop: slots[index].datetimeStop,
        label: slots[index].datetimeStart.split(" ")[1] + " - " + slots[index].datetimeStop.split(" ")[1],
        isBooked: slots[index].isBooked,
        doctorId: slots[index].doctorId,
        patientId: slots[index].patientId
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
                setNumbers(oldNumbers => [...oldNumbers, 1]);
            }
        }
    };


    return (
        <div>
            <br /><br />
            <Space size='large'>
                    {data.map((s) => (
                        <Button
                            key={s.id}
                            onClick={() => handleClick(s)}
                            color={(!s.isBooked) ? "primary" : "danger"}
                            variant="solid"
                        >
                            {s.label}
                </Button>
                    ))}
            </Space>
            </div>
    );
}
