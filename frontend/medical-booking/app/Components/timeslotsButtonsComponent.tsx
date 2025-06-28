
"use client"

import React from 'react';
import "../globals.css";
import { Slot } from "@/app/Models/Slot";   
import { Button, Space } from 'antd';
import {
    updateTimeslot, TimeSlotUpdateRequest,
    createBooking, BookingCreateRequest
} from "@/app/Services/service";
//BookingRequest
//import moment from 'moment'



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


    const timelsotRequest: TimeSlotUpdateRequest = { patientid: '', slotid: '', isbooked: 0 };
    const bookingRequest: BookingCreateRequest = {
        slotid: "",
        patientid: "",
        doctorid: "",
        isbooked: 0,
        cancelledby: undefined,
        bookingorcanceldatetime: undefined
    };


    const handleClick = (value: Slot) => {
        console.log('handleClick ', value.id, value.isBooked, value.patientId);
        //const request: BookingRequest{};
        timelsotRequest.slotid = value.id;
        timelsotRequest.patientid = "00000000-0000-0000-0000-000000000007"; // value.patientId;
        timelsotRequest.isbooked = 1;  // ? value.isBooked==0 : 0;         // ?
        //request.bookingorcanceldatetime = moment(new Date()).format('LLLL');
        //request.cancelledby = value.patientId;                         // ?
        //updateTimeslot(request);
        //
        bookingRequest.slotid = value.id;
        bookingRequest.patientid = "00000000-0000-0000-0000-000000000008";
        bookingRequest.doctorid = "00000000-0000-0000-0000-000000000017";
        bookingRequest.isbooked = 1;
        //bookingRequest.cancelledby = value.id;d
        //bookingRequest.bookingorcanceldatetime = value.id;d
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
