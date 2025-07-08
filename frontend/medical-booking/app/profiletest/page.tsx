/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
import CollapseElement from '../Components/testCollapseComponent';



export default function profileTest() {
    //let specialitySelected = undefined;
    //const [currentRole, setCurrentRole] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        setLoading(false);
    }, []);




    return (
        <div>
            <br></br>
            <br></br>
            <br></br>
            <h2>test profile</h2>
            <br></br>
            <br></br>
            <br></br>
            {
                <div >
                    <br></br>
                    <br></br>
                    {loading ? (
                        <Title>Loading ...</Title>
                    ) : (
                        <CollapseElement />
                    )}
                    <br></br>
                    <br></br>
                </div >
            }
        </div>
    );
}