'use client'

import React from 'react';
import { useEffect, useState } from "react";


export default function CurrentUserComponent() {
    const [currentUserName, setCurrentUserName] = useState("");
    const [currentUserRole, setCurrentUserRole] = useState("");

    useEffect(() => {
        const getUser = async () => {
            const name = localStorage.getItem("username") || "";
            const role = localStorage.getItem("role") || "";
            setCurrentUserName(name);
            setCurrentUserRole(role);
        }
        getUser();
    }, []);

    return (
        <div >
            {currentUserName ? (
                <div>Вы вошли как: <b>{currentUserRole}</b>  <b>{currentUserName}</b></div>
            ) : (
                <div></div>
            )}
        </div >
    );
}