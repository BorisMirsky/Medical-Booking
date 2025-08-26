# Medical-Booking
Система подбора и записи к врачу.


На 26 августа 2025 готовность 90%.

#################################################################################

Стек технологий.
.Net Framework, Web API, Entity Framework, SQLite.
NextJS, React, Typescript, antd.


Авторизация с JWT. Токен хранится в localStorage.
Как локальная БД используется SQLite. Хранится в Medical-Booking\backend\MedicalBookingProject\src\MedicalBookingProject.DataAccess\Database\
Позже переделаю в создание по команде EnsureCreated, но пока в БД лежат готовые юзеры
с разными ролями, и ими можно сразу начинать пользоваться (логины и пароли ниже).

Все пользователи разбиты на три роли: админ, врачи, пациенты.




                  Как пользоваться:
1. Склонировать

2. Поставить пакеты и зависимости:
- В консоли разработчика выполнить 'dotnet restore'.
- Войти в папку 'Medical-Booking\frontend\medical-booking\node_modules' и выполнить 'npm install'.

3. Проверить функциональность разных ролей (пары логин-пароль ниже)

3.1 Войти под админом.
Выбрать врача либо создать нового.
Создать расписание для врача.
Выйти.

3.2 Зарегистрироваться как пациенту либо зайти под готовым. 
Забронировать приём у врача. Можно попробовать отменить бронирование.
Выйти.

3.3 Зайти как врач. 
Открыть своё расписание. Выбрать забронированный (красный) слот. 
Создать приём у врача. Заполнить все формы.
Выйти


                              Готовые пары логин-пароль
   Админ
Admin@gmail.com, AdminPassword
   Пациенты
Nina@mail.de, NinaPassword                    
Alla@mail.uk, AllaPassword
basil@mail.uk, basilpassword
   Врачи
EmilieBlunt@mail.ru, EmilieBluntPassword
JamesBond@mail.ru, JamesBondPassword


