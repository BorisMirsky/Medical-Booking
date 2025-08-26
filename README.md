# Medical-Booking
Система подбора и записи к врачу.


На 26 августа 2025 готовность 90%.

#################################################################################

Стек технологий.
.Net Framework, Web API, Entity Framework, SQLite.
NextJS, React, Typescript, antd.


Авторизация с JWT. Токен хранится в localStorage.
Как локальная БД используется SQLite. Хранится в Medical-Booking\backend\MedicalBookingProject\src\MedicalBookingProject.DataAccess\Database
Позже переделаю в создание по команде EnsureCreated, но пока в БД лежат готовые юзеры
с разными ролями, и ими можно сразу начинать пользоваться (логины и пароли ниже).

Все пользователи разбиты на три роли: админ, врачи, пациенты.




Как пользоваться.
1. Склонировать
2. Поставить пакеты и зависимости:
- В консоли разработчика выполнить 'dotnet restore'.
- Войти в папку 'Medical-Booking\frontend\medical-booking\node_modules' и выполнить 'npm install'.

3. Проверить функциональность разных ролей

Войти под админом (Admin@gmail.com, AdminPassword)
Выбрать врача либо создать нового.
Создать расписание для врача.
Выйти.

Зарегистрироваться как пациенту либо зайти под готовым. 
Nina@mail.de, NinaPassword                    
Alla@mail.uk, AllaPassword
basil@mail.uk, basilpassword
Забронировать приём у врача. Можно попробовать отменить бронирование.
Выйти.


Зайти как врач. 
EmilieBlunt@mail.ru, EmilieBluntPassword
JamesBond@mail.ru, JamesBondPassword
Открыть своё расписание. Выбрать забронированный (красный) слот. 
Создать приём у врача. Заполнить все формы.
Выйти

