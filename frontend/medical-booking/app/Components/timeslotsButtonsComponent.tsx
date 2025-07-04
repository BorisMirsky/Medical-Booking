
"use client"

import React from 'react';
import "../globals.css";
import { Slot } from "@/app/Models/Slot";   
import { Button, Space } from 'antd';
import {
    updateTimeslot, TimeSlotUpdateRequest,
    createBooking, BookingCreateRequest
} from "@/app/Services/service";
//import moment from 'moment';
import { useReducer } from "react";         //useState





export default function TimeslotsButtons(slots: Array<Slot>) {
    const [, forceUpdate] = useReducer(x => x + 1, 0)


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

    const timeslotRequest: TimeSlotUpdateRequest = { patientid: '', slotid: '', isbooked: false };

    const bookingRequest: BookingCreateRequest = {
        slotid: "",
        patientid: "",
        doctorid: "",
        doctorusername: "",
        isbooked: false,
        //cancelledby: undefined,
        //bookingorcanceldatetime: undefined
    };


    const handleClick = (value: Slot) => {
        if (!value.isBooked)
        {
            timeslotRequest.slotid = value.id;
            timeslotRequest.patientid = "192A59D9-43DF-43EC-943A-8E4290386B1E";
            timeslotRequest.isbooked = true;
            //
            bookingRequest.slotid = value.id;
            bookingRequest.patientid = "192A59D9-43DF-43EC-943A-8E4290386B1E";
            bookingRequest.doctorid = value.doctorId;
            //bookingRequest.doctorusername = value.doctorId;
            bookingRequest.isbooked = true;
            updateTimeslot(timeslotRequest);
            createBooking(bookingRequest);
            forceUpdate();
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
