//import '../App.css';
import { Select, FormProps, Button, Form, Input, Space } from 'antd';
const { Option } = Select;
import { registerPatient } from '../Services/service';


export interface PatientRegisterRequest {
    email: string;
    password: string;
    username: string;
    role: string;
    gender: string;
}



export default function PatientRegistration() {

    const [form] = Form.useForm();

    const onFinishFailed: FormProps<PatientRegisterRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('onFinishFailed:', errorInfo);
    }

    const onFinish: FormProps<PatientRegisterRequest>['onFinish'] = (values) => {
        registerPatient(values);
        form.resetFields();
        //console.log('values ', values)
    }


    return (
        <Form
            name="basic"
            labelCol={{ span: 8 }}
            wrapperCol={{ span: 16 }}
            style={{ maxWidth: 600 }}
            initialValues={{ role: "patient" }}
            onFinish={onFinish}
            onFinishFailed={onFinishFailed}
            autoComplete="off"
            form={form}
        >
            <Form.Item<PatientRegisterRequest>
                label="Email"
                name="email"
                rules={[{ required: true, message: 'Please input login!' }]}
            >
                <Input />
            </Form.Item>

            <Form.Item<PatientRegisterRequest>
                label="Password"
                name="password"
                rules={[{ required: true, message: 'Please input password!' }]}
            >
                <Input />
            </Form.Item>

            <Form.Item<PatientRegisterRequest>
                label="UserName"
                name="username"
                rules={[{ required: true, message: 'Please input username!' }]}
            >
                <Input />
            </Form.Item>

            <Form.Item<PatientRegisterRequest>
                label="Role"
                name="role"
                rules={[{ required: true, message: 'Please input role!' }]}
            >
                <Input
                    disabled={true}
                />
            </Form.Item>

            <Form.Item<PatientRegisterRequest>
                label="Gender"
                name="gender"
                rules={[{ required: true, message: 'Please input gender!' }]}
            >
                <Select
                    placeholder="Select a gender"
                >
                    <Option value="male">male</Option>
                    <Option value="female">female</Option>
                </Select>
            </Form.Item>
            <br></br>
            <br></br>
            <Form.Item label={null}>
                <Space size='large'>
                    <Button
                        type="primary"
                        htmlType="submit"
                    >
                        Регистрация
                    </Button>
                    <Button htmlType="reset">
                        Сбросить
                    </Button>
                </Space>
            </Form.Item>
        </Form>
    );
}
