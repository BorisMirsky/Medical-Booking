
import { Select, Space } from 'antd';



export default function SelectDoctorBySpeciality() {
    return (
        <Space size='large'>
            Подбор врача по специализации
            <Select
                style={{ width: 200 }}
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
