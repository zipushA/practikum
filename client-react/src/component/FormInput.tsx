import React from 'react';
import { Controller } from 'react-hook-form';
import { TextField } from '@mui/material';

// 🔹 הגדרת הפרופסים לקומפוננטה
interface FormInputProps {
    name: string;
    label: string;
    type?: string;
    control: any;
    error?: string;
    endAdornment?: React.ReactNode;
}

const FormInput: React.FC<FormInputProps> = ({ name, label, type = 'text', control, error, endAdornment }) => (
    <Controller
        name={name}
        control={control}
        defaultValue=""
        render={({ field }) => (
            <TextField
                {...field}
                label={label}
                type={type}
                fullWidth
                margin="normal"
                error={!!error}
                helperText={error || ''}
                InputProps={{ endAdornment }}
            />
        )}
    />
);

export default FormInput;
