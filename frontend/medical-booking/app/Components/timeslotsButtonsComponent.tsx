
"use client"

import React from 'react';
import "../globals.css";
import { Slot } from "@/app/Models/Slot";   
import { Button, Space } from 'antd';
import {
    updateTimeslot, TimeSlotUpdateRequest,
    createBooking, BookingCreateRequest
} from "@/app/Services/service";
import moment from 'moment';



export default function TimeslotsButtons(slots: Array<Slot> ) {

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
        isbooked: false,
        cancelledby: "",
        bookingorcanceldatetime: ""
    };


    const handleClick = (value: Slot) => {
        timelsotRequest.slotid = value.id;
        timelsotRequest.patientid = "00000000-0000-0000-0000-000000000007"; 
        timelsotRequest.isbooked = true;  
        updateTimeslot(timelsotRequest);
        //
        bookingRequest.slotid = value.id;
        bookingRequest.patientid = "00000000-0000-0000-0000-000000000338";
        bookingRequest.doctorid =  "00000000-0000-0000-0000-000000000217";
        bookingRequest.isbooked = true;
        bookingRequest.cancelledby="00000000-0000-0000-0000-000000004338";
        bookingRequest.bookingorcanceldatetime = moment(new Date()).format('LLLL').toString();
        //
        //updateTimeslot(timelsotRequest);
        createBooking(bookingRequest);
    };


    return (
        <div>
            <Space size='large'>
                {data.map((s) => (

                    <Button
                        key={s.id}
                        onClick={() => handleClick(s)}
                        type="default"
                    >
                        {s.label}
                    </Button>
            ))}
            </Space>
            </div>
    );
}


//   type={"primary" ? {s.isBooked == false } : "danger"}
