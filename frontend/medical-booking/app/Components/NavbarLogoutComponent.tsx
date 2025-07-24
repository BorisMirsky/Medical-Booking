'use client'


import React from 'react';
import { useEffect, useState } from "react";
//import { logOut } from "@/app/Services/service";            // ?


export default function LogoutComponent() {
    const [currentUser, setCurrentUser] = useState("");

    useEffect(() => {
        const logoutUser = async () => {
            const result = localStorage.getItem("username") || "";
            setCurrentUser(result);
        }
        logoutUser();
    }, []);

    const logoutHandling = () => {
        localStorage.clear();
        window.location.reload();
        window.location.href = '/';
    }

    return (
        <div >
            {currentUser ? (
                <button onClick={logoutHandling} style={{ height: 30, width: 60 }}>
                    LogOut
                </button>
            ) : (
                <div></div>
            )}

        </div >
    );
}
