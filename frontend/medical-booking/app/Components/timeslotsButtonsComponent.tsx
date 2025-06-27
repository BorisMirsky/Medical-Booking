
"use client"

import React from 'react';
import "../globals.css";
import { Slot } from "@/app/Models/Slot";   
import { Button, Space } from 'antd';
import { updateBooking, BookingRequest } from "@/app/Services/service";
import moment from 'moment'



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


    //   const processedSlots: MyResult = {};
    const request: BookingRequest = {};


    const handleClick = (value: Slot) => {
        //const request: BookingRequest{};
        request.id = value.id;
        request.isbooked = 1;  // ? value.isBooked==0 : 0;         // ?
        request.patientid = value.patientId;
        request.bookingorcanceldatetime = moment(new Date()).format('LLLL');
        //request.cancelledby = value.patientId;                         // ?

        const runUpdateBooking = async () => {
            const responce = await updateBooking(request);
            console.log(responce);
        }
        runUpdateBooking();
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
