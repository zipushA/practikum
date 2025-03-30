
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
        defaultValues: {
            email: '', // ערך התחלתי ריק
            password: '', // ערך התחלתי ריק
        },
    });
    const [showPassword, setShowPassword] = useState(false);

    const handleClickShowPassword = () => {
        setShowPassword(!showPassword);
    };

    const onSubmit = (data: any) => {
        console.log('נתונים:', data);
    };

    return (
        <Container maxWidth="xs" sx={{ display: 'flex', justifyContent: 'center', marginTop: '50px' }}>
            <Card sx={{ padding: '30px', backgroundColor: '#FFFCF5', width: '100%', boxShadow: '0 4px 10px rgba(0,0,0,0.1)', borderRadius: '10px' }}>
                <Typography variant="h4" align="center" sx={{ color: '#00A3A3', fontWeight: 'bold' }}>התחברות</Typography>
                <form onSubmit={handleSubmit(onSubmit)}>

                    {/* 🔹 שדה אימייל */}
                    <FormInput
                        name="email"
                        label="אימייל"
                        control={control}
                        error={errors.email ? errors.email.message : undefined}
                        sx={{ 
                            '& input': {
                                color: '#00A3A3', // צבע טקסט
                                '&::placeholder': { color: '#00A3A3' }, // צבע ה-placeholder
                            },
                            '& .MuiOutlinedInput-root': {
                                '&.Mui-focused fieldset': {
                                    borderColor: '#00A3A3', // צבע גבול כשממוקדים
                                },
                                '&:hover fieldset': {
                                    borderColor: '#00A3A3', // צבע גבול כשמרחפים
                                },
                            },
                            '& label': {
                                color: '#00A3A3', // צבע הלייבל
                                '&.Mui-focused': {
                                    color: '#00A3A3', // צבע הלייבל כשממוקדים
                                },
                                '&.Mui-error': {
                                    color: '#00A3A3', // צבע הלייבל כאשר יש שגיאה
                                },
                            },
                            marginBottom: '20px' // הוספת רווח בין השדות
                        }} 
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
                                <IconButton onClick={handleClickShowPassword} edge="end" sx={{ color: '#00A3A3' }}>
                                    {showPassword ? <VisibilityOff /> : <Visibility />}
                                </IconButton>
                            </InputAdornment>
                        }
                        sx={{ 
                            '& input': {
                                color: '#00A3A3', // צבע טקסט
                                '&::placeholder': { color: '#00A3A3' }, // צבע ה-placeholder
                            },
                            '& .MuiOutlinedInput-root': {
                                '&.Mui-focused fieldset': {
                                    borderColor: '#00A3A3', // צבע גבול כשממוקדים
                                },
                                '&:hover fieldset': {
                                    borderColor: '#00A3A3', // צבע גבול כשמרחפים
                                },
                            },
                            '& label': {
                                color: '#00A3A3', // צבע הלייבל
                                '&.Mui-focused': {
                                    color: '#00A3A3', // צבע הלייבל כשממוקדים
                                },
                                '&.Mui-error': {
                                    color: '#00A3A3', // צבע הלייבל כאשר יש שגיאה
                                },
                            },
                            marginBottom: '20px' // הוספת רווח בין השדות
                        }} 
                    />

                    <Button type="submit" variant="contained" fullWidth sx={{ backgroundColor: '#00A3A3', marginTop: '20px', color: '#fff', '&:hover': { backgroundColor: '#006666' } }}>
                        התחבר
                    </Button>
                </form>
                <Typography align="center" sx={{ marginTop: '15px' }}>
                    <Link href="#" sx={{ color: '#00A3A3', textDecoration: 'underline', textDecorationColor: '#00A3A3', '&:hover': { color: '#00A3A3', textDecoration: 'underline' } }}>
                        אין לך סיסמא עדיין? לחצי כאן
                    </Link>
                </Typography>
            </Card>
        </Container>
    );
};

export default LoginForm;





