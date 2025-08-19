/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
import CollapseElement from '../Components/adminCollapseComponent';



export default function profileAdmin() {
    const [currentRole, setCurrentRole] = useState("");
    const [currentName, setCurrentName] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        const name = localStorage.getItem("username") || "";
        setCurrentRole(role);
        setCurrentName(name);
        setLoading(false);
    }, []);




    return (
        <div>
        <div>
            <br></br>
            <br></br>
            {
                    (currentRole === 'Admin') ? (
            <div>
            <br></br>
            <h2>Профиль админа {currentName}</h2>
            <br></br>
            <br></br>
            <br></br>
                    {loading ? (
                        <Title>Loading ...</Title>
                    ) : (
                            <CollapseElement />
                    )}

                </div >
                    ) : (
                            <div> Только для залогинившегося Админа</div>
            )}
        </div>
        </div>
    );
}