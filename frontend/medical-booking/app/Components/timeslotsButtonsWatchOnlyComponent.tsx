
"use client"

import React from 'react';
import "../globals.css";
import { Slot } from "@/app/Models/Slot";
import { Button, Space } from 'antd';


export default function TimeslotsButtonsWatchOnly(slots: Array<Slot>) {

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



    return (
        <div>
            <Space size='large'>
                {data.map((s) => (

                    <Button
                        key={s.id}
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


//   type={"primary" ? {s.isBooked == false } : "danger"}
