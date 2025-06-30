
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
//import { useState, useCallback  } from "react";  


export default function TimeslotsButtons(slots: Array<Slot>) {
    //const [count, setCount] = useState(0);

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

    const timelsotRequest: TimeSlotUpdateRequest = { patientid: '', slotid: '', isbooked: false };

    const bookingRequest: BookingCreateRequest = {
        slotid: "",
        patientid: "",
        doctorid: "",
        isbooked: false
        //cancelledby: undefined,
        //bookingorcanceldatetime: undefined
    };

    //const runRerender = useCallback(() => {
    //    setCount(count + 1);
    //}, []);

    const handleClick = (value: Slot) => {
        timelsotRequest.slotid = value.id;
        timelsotRequest.patientid = "192A59D9-43DF-43EC-943A-8E4290386B1E";
        //timelsotRequest.isbooked = (!value.isBooked) ? true : false;
        timelsotRequest.isbooked = true;
        //
        bookingRequest.slotid = value.id;
        bookingRequest.patientid = "192A59D9-43DF-43EC-943A-8E4290386B1E";
        bookingRequest.doctorid = value.doctorId;
        //bookingRequest.isbooked = (!value.isBooked) ? true : false;
        bookingRequest.isbooked = true;
        updateTimeslot(timelsotRequest);
        createBooking(bookingRequest);
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
