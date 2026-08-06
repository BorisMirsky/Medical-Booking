"use client"

import React from 'react';
import "@/app/globals.css";
import { Slot } from "@/app/Models/Slot";
import { Button} from 'antd';


export default function TimeslotsButtonsWatchOnly(slots: Array<Slot>) {

    const slotsArray: Array<Slot> = Object.values(slots);
    const sortedSlots = [...slotsArray].sort((a, b) => {
        return a.datetimeStart.localeCompare(b.datetimeStart);
    });

    const data = sortedSlots.map((slot, index) => ({
        key: index,
        id: slot.id,
        datetimeStart: slot.datetimeStart,
        datetimeStop: slot.datetimeStop,
        label: slot.datetimeStart.split(" ")[1] + " - " + slot.datetimeStop.split(" ")[1],
        isBooked: slot.isBooked,
        doctorId: slot.doctorId,
        patientId: slot.patientId
    }));

    return (
        <div>
            <div
                style={{
                    display: 'grid',
                    gridTemplateColumns: 'repeat(5, 1fr)',
                    gap: '10px',
                    maxWidth: '800px'
                }}
            >
                {data.map((s) => (
                    <Button
                        key={s.id}
                        color={(!s.isBooked) ? "primary" : "danger"}
                        variant="solid"
                        style={{
                            width: '100%',
                            height: '40px'
                        }}
                    >
                        {s.label}
                    </Button>
                ))}
            </div>
        </div>
    );
}
