"use client"

import React from 'react';
import styles from "./page.module.css";
import { Button, Space }  from "antd";
import { useEffect } from "react";


export default function Home() {
    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        // эта страница для незалогинившегося юзера
        if (role == "doctor") {
            window.location.href = 'profiledoctor';
        }
        else if(role == "admin") {
            window.location.href = 'profileadmin';
        }
        else if (role == "patient") {
            window.location.href = 'profilepatient';
        }
    }, []);


    const loginAdminPage = async () => {
        console.log("loginAdminPage");
        window.location.href = 'entranceadmin';
        //router.push("/updateorder?id=" + id);
    };

    const loginPatientPage = async () => {
        console.log("loginPatientPage");
        window.location.href = 'entrancepatient';
        //router.push("/updateorder?id=" + id);
    };

    const loginDoctorPage = async () => {
        console.log("loginDoctorPage");
        window.location.href = 'entrancedoctor';
        //router.push("/updateorder?id=" + id);
    };


      return (
          <div className={styles.page}>
              <h1>Система бронирования посещений врача </h1>
              <div>
                  <Space size='large'>
                  <Button
                      onClick={() => loginAdminPage()}
                      style={{ flex: 1 }}
                  >
                      Вход для админа</Button>
                  <Button
                      onClick={() => loginPatientPage()}
                      style={{ flex: 1 }}
                  >
                      Вход для пациента</Button>

                  <Button
                      onClick={() => loginDoctorPage()}
                      style={{ flex: 1 }}
                  >
                          Вход для врача</Button>
                  </Space>
              </div>
          </div >
      );
}
