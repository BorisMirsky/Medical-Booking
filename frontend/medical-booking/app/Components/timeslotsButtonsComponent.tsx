///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import "../globals.css";
import { SlotObject } from "@/app/Models/Slot";   //Slot
import { Button } from 'antd';
//import { useState, useEffect } from "react";



//Array<MySlot>
//type MySlot = Record<string, object>;
//Array<Slot>


interface MyResult {
    [key: string]: Array<SlotObject>;
}

export default function TimeslotsButtons(slots: MyResult ) {
    //const slotsConverted = Array.from(slots);



    //const data = slots.map((index: number, slot: Slot) => ({
    //    key: index,
    //    uniqid: slot.id,
    //    datetimeStart: slot.datetimeStart,
    //    datetimeStop: slot.datetimeStop,
    //    isBooked: slot.isBooked
    //}));


    const handleClick = () => {
        //console.log("TimeslotsButtons ", slotsConverted);
        console.log("TimeslotsButtons1 ", slots);
    };


    return (
        <div>
            

            {
                <Button
                    onClick={handleClick}
                >
                    timeslot
                </Button>
            }

        </div>
            );
}



//{
//    data.map(dataItem => (
//        <Button
//            key={dataItem.key}
//            onClick={handleClick}
//        >
//            timeslot
//        </Button>))
//}

//<Button
//    onClick={handleClick}
//>
//    timeslot
//</Button>))

