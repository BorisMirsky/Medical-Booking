﻿
"use client"

import React from 'react';
import "../globals.css";
import { Slot } from "@/app/Models/Slot";   
import { Button, Space } from 'antd';
import {
    updateTimeslot, TimeSlotUpdateRequest,
    createBooking, BookingCreateRequest, DoctorSheduleProps
} from "@/app/Services/service";
//import { useState } from "react";         //useState, useReducer



export default function TimeslotsButtons({ numbers, setNumbers, slots }: DoctorSheduleProps) {

    //const data1 = Object.keys(slots).map((slot, index) => ({
    //    isBooked: slots[index].isBooked,
    //}));


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
            timeslotRequest.patientid = "98C2849A-B6DC-453D-8426-50307F46DD22";
            timeslotRequest.isbooked = true;
            bookingRequest.slotid = value.id;
            bookingRequest.patientid = "98C2849A-B6DC-453D-8426-50307F46DD22";
            bookingRequest.doctorid = value.doctorId;
            bookingRequest.isbooked = true;
            updateTimeslot(timeslotRequest);
            createBooking(bookingRequest);
            setNumbers(oldNumbers => [...oldNumbers, 1]);
            //console.log("handleClick numbers ", numbers);
        }
    };


    return (
        <div><p>{numbers}</p><br></br><br></br>
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
