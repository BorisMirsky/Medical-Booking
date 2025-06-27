
"use client"

import React from 'react';
import "../globals.css";
import { Slot } from "@/app/Models/Slot";   
import { Button } from 'antd';



export default function TimeslotsButtons(slots: Array<Slot> ) {

    const data = Object.keys(slots).map((slot, index) => ({
        key: index,
        id: slots[index].id,
        datetimeStart: slots[index].datetimeStart,
        datetimeStop: slots[index].datetimeStop,
        label: slots[index].datetimeStart.split(" ")[1] + " - " + slots[index].datetimeStop.split(" ")[1],
        isBooked: slots[index].isBooked
    }));


    const handleClick = (value: string) => {
        console.log(value);
    };


    return (
            <div>
                {data.map((s) => (
                    <Button
                        key={s.id}
                        onClick={() => handleClick(s.id)}
                    >
                        {s.label}
                    </Button>
                ))}
            </div>
    );
}



