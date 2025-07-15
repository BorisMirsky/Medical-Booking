
"use client"

import React from 'react';
import "../globals.css";
import { Slot } from "@/app/Models/Slot";   
import { Button, Space } from 'antd';
import {
    updateTimeslot, TimeSlotUpdateRequest,
    createBooking, BookingCreateRequest
} from "@/app/Services/service";
//import { useState } from "react";         //useState, useReducer





export default function TimeslotsButtons(slots: Array<Slot>) {

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
        if (!value.isBooked)
        {
            timeslotRequest.slotid = value.id;
            timeslotRequest.patientid = "A157E16F-26EA-44FB-B01E-FD26A4ACDDCD";
            timeslotRequest.isbooked = true;
            bookingRequest.slotid = value.id;
            bookingRequest.patientid = "A157E16F-26EA-44FB-B01E-FD26A4ACDDCD";
            bookingRequest.doctorid = value.doctorId;
            bookingRequest.isbooked = true;
            updateTimeslot(timeslotRequest);
            createBooking(bookingRequest);
        }
    };


    return (
        <div>
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
