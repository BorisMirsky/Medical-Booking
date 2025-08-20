
"use client"

import React from 'react';
import CollapseElement from '../Components/doctorCollapseComponent';
import { useEffect, useState } from "react";
import Title from "antd/es/typography/Title";



export default function ProfileDoctor() { 
    const [currentUserName, setCurrentUserName] = useState("");
    const [currentUserRole, setCurrentUserRole] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        setLoading(false);
        const getUser = async () => {
            const name = localStorage.getItem("username") || "";
            const role = localStorage.getItem("role") || "";
            if (name != undefined) {
                setCurrentUserName(name);
                setCurrentUserRole(role);
            }
        }
        getUser();
    }, []);

    return (
        <div>
            <div>
                <br />
                <br />
                <br />
                {
                    (currentUserRole === 'doctor') ? (
                <div >
                            <br />
                    <h2>Профиль врача {currentUserName}</h2>
                            <br />
                            <br />
                    {loading ? (
                        <Title>Loading ...</Title>
                    ) : (
                    <CollapseElement />
                    )}
                        </div >
                    ) : (
                        <div> Только для залогинившегося врача</div>
                    )}
            </div>
            </div>
        );
}