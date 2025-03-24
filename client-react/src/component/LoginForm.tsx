
import React, { useState } from 'react';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as Yup from 'yup';
import { InputAdornment, IconButton, Button, Container, Typography, Card, Link } from '@mui/material';
import { Visibility, VisibilityOff } from '@mui/icons-material';
import FormInput from './FormInput'; // ייבוא הקומפוננטה הגנרית

// 🔹 ולידציה
const schema = Yup.object().shape({
    email: Yup.string().email('אימייל לא תקין').required('אימייל הוא שדה חובה'),
    password: Yup.string().required('סיסמא היא שדה חובה'),
});

const LoginForm: React.FC = () => {
    const { control, handleSubmit, formState: { errors } } = useForm({
        resolver: yupResolver(schema),
    });
    const [showPassword, setShowPassword] = useState(false);

    const handleClickShowPassword = () => {
        setShowPassword(!showPassword);
    };

    const onSubmit = (data: any) => {
        console.log('נתונים:', data);
    };

    return (
        <Container maxWidth="xs" style={{ display: 'flex', justifyContent: 'center', marginTop: '50px' }}>
            <Card style={{ padding: '30px', backgroundColor: '#FFFCF5', width: '100%', boxShadow: '0 4px 10px rgba(0,0,0,0.1)', borderRadius: '10px' }}>
                <Typography variant="h4" align="center" style={{ color: '#008080', fontWeight: 'bold' }}>התחברות</Typography>
                <form onSubmit={handleSubmit(onSubmit)}>

                    {/* 🔹 שדה אימייל */}
                    <FormInput
                        name="email"
                        label="אימייל"
                        control={control}
                        error={errors.email ? errors.email.message : undefined}
                    />

                    {/* 🔹 שדה סיסמא עם כפתור הצגת סיסמא */}
                    <FormInput
                        name="password"
                        label="סיסמא"
                        type={showPassword ? 'text' : 'password'}
                        control={control}
                        error={errors.password ? errors.password.message : undefined}
                        endAdornment={
                            <InputAdornment position="end">
                                <IconButton onClick={handleClickShowPassword} edge="end">
                                    {showPassword ? <VisibilityOff style={{ color: '#008080' }} /> : <Visibility style={{ color: '#008080' }} />}
                                </IconButton>
                            </InputAdornment>
                        }
                    />

                    <Button type="submit" variant="contained" fullWidth style={{ backgroundColor: '#008080', marginTop: '20px', color: '#fff' }}>
                        התחבר
                    </Button>
                </form>
                <Typography align="center" style={{ marginTop: '15px' }}>
                    <Link href="#" style={{ color: '#008080', textDecoration: 'underline', textDecorationColor: '#008080' }}>
                        אין לך סיסמא עדיין?
                         לחצי כאן
                    </Link>
                </Typography>
            </Card>
        </Container>
    );
};

export default LoginForm;
