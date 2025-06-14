"use client"

import React from 'react';
import styles from "./page.module.css";
import { Button, Space }  from "antd";



export default function Home() {

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
