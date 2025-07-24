'use client'

import React from 'react';
import { useEffect, useState } from "react";


export default function CurrentUserComponent() {
    const [currentUser, setCurrentUser] = useState("");

    useEffect(() => {
        const getUser = async () => {
            const result = localStorage.getItem("username") || "";
            if (result != undefined) {
                setCurrentUser(result);
            }
        }
        getUser();
    }, []);

    return (
        <div >
            {currentUser ? (
                <div>Вы вошли как <b>{currentUser}</b></div>
            ) : (
                <div></div>
            )}
        </div >
    );
}