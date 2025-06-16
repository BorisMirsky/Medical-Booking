//import '../App.css';
import { Select, Space } from 'antd';
//const { Option } = Select;


export default function SelectDoctorBySpeciality() {
    return (
        <Space size='large'>
            Подбор врача по специализации
            <Select
                style={{ width: 200 }}
                //onChange={handleFunction}
                options={[
                    { value: 'Neurologist', label: 'Невролог' },
                    { value: 'Surgeon', label: 'Хирург' },
                    { value: 'Oncologist', label: 'Онколог' },
                    { value: 'Dentist', label: 'Дантист' }
                ]}
            />
        </Space>
    );
}
