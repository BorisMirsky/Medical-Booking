

export interface UserRegistrationRequest {
    email: string;
    password: string;
    username: string;
    role: string;
}

export interface UserLoginRequest {
    email: string;
    password: string;
}

export interface CurrentUser {
    id: string;
    username: string;
    role: string;
    isactive: boolean;
    token: string;
    password: string;
}

export interface DoctorRegisterRequest {
    email: string;
    password: string;
    username: string;
    role: string;
    speciality: string;
    gender: string;
}

export interface PatientRegisterRequest {
    email: string;
    password: string;
    username: string;
    role: string;
    gender: string;
}

export interface SheduleCreateRequest {
    doctorid: string;
    startday: string;
    days: string;
    speciality: string;
    username: string; 
    timestart: string;
    timestop: string;
    timechunk: string;
}


export interface TimeSlotUpdateRequest {
    patientid: string;
    slotid: string;
    isbooked: number;
}


//export interface BookingCreateRequest {                   
//    doctorid: string;
//    startday: string;
//    days: string;
//    speciality: string;
//    username: string;
//    timestart: string;
//    timestop: string;
//    timechunk: string;
//}

export interface DoctorSheduleRequest {
    id: string;
    speciality: string;
    username: string;
    day: string;
}

export interface BookingCreateRequest {                             
    slotid: string;
    patientid: string;
    doctorid: string;
    isbooked: number;
    cancelledby?: string; 
    bookingorcanceldatetime?: string;
}



// doctors by speciality
export const getDoctorsBySpeciality = async (speciality: string) => {
    //const token = localStorage.getItem('token');
    const response = await fetch("http://localhost:5032/doctors/" + speciality, {
        headers: {
            'Content-type': 'application/json'
            //'Authorization': `Bearer ${token}`,
        },
        method: 'GET',
        mode: 'cors'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Not response", { cause: response });
                //window.location.href = 'noauthorized';
            }
            else {
                return response.json();
            }
        })
        .then(data => {
            return data;
        })
        .catch(function(err) {
            console.log('Error: ', err);
        });
    return response;
};


// all doctors
export const getDoctorsFetch = async () => {
    //const token = localStorage.getItem('token');
    const response = await fetch("http://localhost:5032/doctors/GetDoctors", {
        headers: {
            'Content-type': 'application/json'
            //'Authorization': `Bearer ${token}`,
        },
        method: 'GET',
        mode: 'cors'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Not response", { cause: response });
            }
            else {
                return response.json();
            }
        })
        .then(data => {
            //console.log('data: ', data);
            return data;
        })
        .catch(function (err) {
            console.log('Error: ', err);
        });
    return response;
};


// all patients
export const getPatientsFetch = async () => {
    //const token = localStorage.getItem('token');
    const response = await fetch("http://localhost:5032/patients/GetPatients", {
        headers: {
            'Content-type': 'application/json'
            //'Authorization': `Bearer ${token}`,
        },
        method: 'GET',
        mode: 'cors'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Not response", { cause: response });
            }
            else {
                return response.json();
            }
        })
        .then(data => {
            //console.log('data: ', data);
            return data;
        })
        .catch(function (err) {
            console.log('Error: ', err);
        });
    return response;
};



export const getDoctorById = async (id: string) => {
    const response = await fetch("http://localhost:5032/doctors/" + id, {
        headers: {
            'Content-type': 'application/json'
        },
        method: 'GET'
    })
        .then((response) => {
            if (!response.ok) {
                console.log('!response.ok ');
            }
            else {
                return response.json();
            }
        })
        .then(data => {
            return data;
        })
        //.catch(err => { console.log('Error: ', err); });
        .catch(e => console.log('Connection error', e));
    return response;
};



export const registerDoctor = async (request: DoctorRegisterRequest) => {
    //const token = localStorage.getItem('token');
    await fetch("http://localhost:5032/doctors/register", {
        method: 'POST',
        mode: 'cors',
        //credentials: true,
        headers: {
            'Content-Type': 'application/json',
            //'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify(request)
    }).then(response => {
        if (!response.ok) {
            alert("Ошибка регистрации");
            console.log("Ошибка регистрации");
        }
        else {
            alert("Регистрация прошла успешно")
            //window.location.href = 'login';
        }
    }).catch(err => {
        console.log('registerError: ', err);
    });
}



export const registerPatient = async (request: PatientRegisterRequest) => {
    //const token = localStorage.getItem('token');
    await fetch("http://localhost:5032/patients/registerpatient", {
        method: 'POST',
        mode: 'cors',
        //credentials: true,
        headers: {
            'Content-Type': 'application/json',
            //'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify(request)
    }).then(response => {
        if (!response.ok) {
            alert("Ошибка регистрации");
            console.log("Ошибка регистрации");
        }
        else {
            alert("Регистрация прошла успешно")
            //window.location.href = 'login';
        }
    }).catch(err => {
        console.log('registerError: ', err);
    });
}



export const createShedule = async (request: SheduleCreateRequest) => {
    //const token = localStorage.getItem('token');
    await fetch("http://localhost:5032/timeslots/createtimeslot", {      
        method: 'POST',
        //mode: 'cors',
        //credentials: true,
        headers: {
            'Content-Type': 'application/json',
            //'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify(request)
    }).then(response => {
        if (!response.ok) {
            alert("Ошибка создания расписания");
            console.log("Ошибка создания расписания");
            throw new Error("Not 2xx response", { cause: response });
        }
        else {
            alert("Расписание создано")
            //window.location.href = 'login';
        }
    }).catch(function(err) {
        console.log('Error: ', err);
    });
}



export const getSlotsByDoctorId = async (id: string) => {
    const url = 'http://localhost:5032/timeslots/';      //ByDoctorId 
    //const token = localStorage.getItem('token');
    const response = await fetch(url + id, {
        headers: {
            'Content-type': 'application/json'
            //'Authorization': `Bearer ${token}`,
        },
        method: 'GET',
        mode: 'cors'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Not response", { cause: response });
                //window.location.href = 'noauthorized';
            }
            else {
                return response.json();
            }
        })
        .then(data => {
            //console.log('data ', data);
            return data;
        })
        .catch(function (err) {
            console.log('Error: ', err);
        });
    return response; 
};



export const updateTimeslot = async (request: TimeSlotUpdateRequest) => {
    //const token = localStorage.getItem('token');`
    await fetch("http://localhost:5032/timeslots/updatetimeslot", {
        method: 'PATCH',  
        //mode: 'cors',
        //credentials: true,
        headers: {
            'Content-Type': 'application/json',
            //'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify(request)
    })
    .then(response => {
        if (!response.ok) {
            alert("Ошибка обновления записи к врачу");
            //console.log("Ошибка обновления записи к врачу");
            throw new Error("Not 2xx response", { cause: response });
        }
        else {
            alert("Запись к врачу обновлена")
        }
    }).catch(function (err) {
        console.log('Error: ', err);
    });
};


export const createBooking = async (request: BookingCreateRequest) => {
    //const token = localStorage.getItem('token');
    await fetch("http://localhost:5032/bookings/createbooking", {
        method: 'POST',
        //mode: 'cors',
        //credentials: true,
        headers: {
            'Content-Type': 'application/json',
            //'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify(request)
    }).then(response => {
        if (!response.ok) {
            alert("Ошибка создания бронирования");
            //console.log("Ошибка создания бронирования");
            throw new Error("Not 2xx response", { cause: response });
        }
        else {
            alert("Бронирование создано")
            //window.location.href = 'login';
        }
    }).catch(function (err) {
        console.log('Error: ', err);
    });
}



// need ?
export function uniqueDays(mySlots: object) {
    console.log('mySlots ', mySlots);
    const doctorWorkingDays = new Set(); 
    for (const variable in mySlots) {
        const day = mySlots[variable as keyof typeof mySlots]["datetimeStart"]; //   .split(" ")[0];
        console.log('variable ', variable);
        doctorWorkingDays.add(day);
    }
    return doctorWorkingDays;
};