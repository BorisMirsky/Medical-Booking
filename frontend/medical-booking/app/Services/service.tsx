

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


let doctors: object = undefined; 


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
                throw new Error("Not 2xx response", { cause: response });
                //console.log('response.ok'); // 'token ', '\n', token);
                //window.location.href = 'noauthorized';
            }
            else {
                //console.log('response.json() ', response.json());
                return response.json();
            }
        })
        .then(data => {
            console.log('data ', data);
            return data;
        })
        .catch(function(err) {
            console.log('Error: ', err);
        });
    return response;
};


//getDoctorsBySpeciality/
export const getDoctorsBySpeciality1 = async (speciality: string) => {
    const response = await fetch("http://localhost:5032/doctors/" + speciality, {
        headers: {
            'Content-type': 'application/json'
        },
        method: 'GET',
        mode: 'cors'
    })
        .then(response => (response.ok)
            ? response.json()
            : Promise.reject("not ok " + response.status)
         )
        .catch((err) => {
            console.warn('Error: ', err);
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



//export const getOneOrder = async (id: string) => {
//    const token = localStorage.getItem('token');
//    const response = await fetch("http://localhost:5134/orders/" + id, {
//        headers: {
//            'Content-type': 'application/json',
//            'Authorization': `Bearer ${token}`
//        },
//        method: 'GET'
//    })
//        .then((response) => {
//            if (!response.ok) {
//                //console.log('!response.ok ', '\n', token, '\n');
//                console.log('!response.status ', '\n', response.headers);
//                //window.location.href = 'error';
//            }
//            else {
//                return response.json();
//            }
//        })
//        .then(data => {
//            return data;
//        })
//        .catch(err => {
//            console.log('Error: ', err);
//        });
//    return response;
//};

//export const createOrder = async (orderRequest: OrderRequest) => {
//    //console.log('orderRequest ', orderRequest)
//    const token = localStorage.getItem('token');
//    await fetch("http://localhost:5134/orders/", {
//        method: 'POST',
//        headers: {
//            'Content-type': 'application/json',
//            'Authorization': `Bearer ${token}`,
//        },
//        body: JSON.stringify(orderRequest)
//    }).catch(error => console.log("createOrderError: ", error));
//}

//export const updateOrder = async (id: string, orderRequest: OrderRequest) => {
//    const token = localStorage.getItem('token');
//    await fetch('http://localhost:5134/orders/' + id, {
//        method: 'PUT',
//        headers: {
//            'Content-type': 'application/json',
//            'Authorization': `Bearer ${token}`,
//        },
//        body: JSON.stringify(orderRequest)
//    });
//}

//export const loginUser = async (request: UserLoginRequest) => {
//    let username: string = "";
//    let token: string = ""
//    let role: string = "";

//    await fetch("http://localhost:5134/accounts/login", {
//        method: 'POST',
//        mode: 'cors',
//        headers: {
//            'Content-Type': 'application/json',
//        },
//        body: JSON.stringify(request)
//    })
//        .then((response) => {
//            if (!response.ok) {
//                alert("Неверные логин или пароль")
//            }
//            else {
//                return response.json();
//            }
//        })
//        .then(data => {
//            username = data['userName'];
//            role = data['rolename'];
//            token = data['token'];
//            localStorage.setItem('username', username);
//            localStorage.setItem('role', role);
//            localStorage.setItem('token', token);
//            window.location.href = '/';
//        })
//        .catch(err => {
//            console.log('Error: ', err);
//        });
//}

//export const registerUser = async (request: UserRegistrationRequest) => {
//    const token = localStorage.getItem('token');
//    await fetch("http://localhost:5134/accounts/register", {
//        method: 'POST',
//        mode: 'cors',
//        //credentials: true,
//        headers: {
//            'Content-Type': 'application/json',
//            'Authorization': `Bearer ${token}`
//        },
//        body: JSON.stringify(request)
//    }).then(response => {
//        if (!response.ok) {
//            alert("Ошибка регистрации");
//            console.log("Ошибка регистрации");
//        }
//        else {
//            alert("Регистрация прошла успешно")
//            //window.location.href = 'login';
//        }
//    }).catch(err => {
//        console.log('registerError: ', err);
//    });
//}

//export const logOut = async () => {
//    await fetch("http://localhost:5134/accounts/logout/");
//}
