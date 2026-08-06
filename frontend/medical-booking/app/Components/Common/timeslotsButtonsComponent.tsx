"use client"

import React from 'react';
import "@/app/globals.css";
import { Slot } from "@/app/Models/Slot";
import { Button } from 'antd';
import {
    updateTimeslot, TimeSlotUpdateRequest,
    createBooking, BookingCreateRequest, TimeslotsButtonsProps    // DoctorSheduleProps
} from "@/app/Services/service";
import { useState, useEffect } from "react";



export default function TimeslotsButtons({
                            setNumbersAction,
                            slots,
                            onSlotsUpdate
                        }: 
                             TimeslotsButtonsProps) {
    const [currentUserRole, setCurrentUserRole] = useState("");
    const [currentUserId, setCurrentUserId] = useState("");
    const [localSlots, setLocalSlots] = useState<Slot[]>(slots || []);



    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        setCurrentUserRole(role);
        const id = localStorage.getItem("id") || "";
        setCurrentUserId(id);
    }, []);

    const sortedSlots = [...localSlots].sort((a, b) => {
        return a.datetimeStart.localeCompare(b.datetimeStart);
    });

    const data = Object.keys(sortedSlots).map((slot, index) => ({
        key: index,
        id: sortedSlots[index].id,
        datetimeStart: sortedSlots[index].datetimeStart,
        datetimeStop: sortedSlots[index].datetimeStop,
        label: sortedSlots[index].datetimeStart.split(" ")[1] + " - " + sortedSlots[index].datetimeStop.split(" ")[1],
        isBooked: sortedSlots[index].isBooked,
        doctorId: sortedSlots[index].doctorId,
        patientId: sortedSlots[index].patientId
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

    const handleClick = async (clickedSlot: Slot) => {
        if (currentUserRole == 'patient') {
            if (clickedSlot.isBooked === 0) {
                timeslotRequest.slotid = clickedSlot.id;
                timeslotRequest.patientid = currentUserId;
                timeslotRequest.isbooked = true;

                bookingRequest.slotid = clickedSlot.id;
                bookingRequest.patientid = currentUserId;
                bookingRequest.doctorid = clickedSlot.doctorId;
                bookingRequest.isbooked = true;

                try {
                    await updateTimeslot(timeslotRequest);
                    await createBooking(bookingRequest);

                    const updatedSlots: Slot[] = localSlots.map(slot => {
                        if (slot.id === clickedSlot.id) {
                            return {
                                ...slot,
                                isBooked: 1, 
                                patientId: currentUserId
                            };
                        }
                        return slot;
                    });
                    setLocalSlots(updatedSlots);
                    if (onSlotsUpdate) {
                        onSlotsUpdate(updatedSlots);
                    }
                    setNumbersAction((oldNumbers: number[]) => [...oldNumbers, 1]);
                } catch (error) {
                    console.error("Error booking slot:", error);
                }
            } else {
                console.log("Slot is already booked");
            }
        } else {
            console.log("User is not a patient");
        }
    };

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
                {data.map((s) => {
                    //console.log(`Button ${s.label} isBooked:`, s.isBooked, "type:", typeof s.isBooked);
                    return (
                        <Button
                            key={s.id}
                            onClick={() => handleClick(s)}
                            color={s.isBooked === 0 ? "primary" : "danger"}
                            variant="solid"
                            style={{
                                width: '100%',
                                height: '40px'
                            }}
                        >
                            {s.label}
                        </Button>
                    );
                })}
            </div>
        </div>
    );
}