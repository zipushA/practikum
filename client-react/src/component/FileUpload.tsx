
// import React, { useState } from 'react';
// import { Button, CircularProgress, Typography, Box } from '@mui/material';
// import axios from 'axios';
// import '../Style/FileUpload.css'

// const FileUpload = () => {
//   const [file, setFile] = useState<File | null>(null);
//   const [progress, setProgress] = useState(0);
//   const [loading, setLoading] = useState(false);
//   const [message, setMessage] = useState<string>("");

//   const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
//     if (e.target.files) {
//       setFile(e.target.files[0]);
//       setMessage(""); // Reset message on new file selection
//     }
//   };

//   const handleUpload = async () => {
//     if (!file) return;

//     setLoading(true);
//     setMessage("");

//     try {
//       const response = await axios.get('https://localhost:7082/api/Teacher/Upload-url', {
//         params: { fileName: file.name, contentType: file.type }
//       });

//       const presignedUrl = response.data.url;

//       await axios.put(presignedUrl, file, {
//         headers: {
//           'Content-Type': file.type,
//         },
//         onUploadProgress: (progressEvent) => {
//           const percent = Math.round(
//             (progressEvent.loaded * 100) / (progressEvent.total || 1)
//           );
//           setProgress(percent);
//         },
//       });

//       setMessage('הקובץ הועלה בהצלחה');
//     } catch (error) {
//       console.error('שגיאה בהעלאה', error);
//       setMessage('שגיאה בהעלאה');
//     } finally {
//       setLoading(false);
//     }
//   };

//   return (
//     <Box className="file-upload-container">
//       <Typography className="h1" variant="h4"  gutterBottom>
//         העלאת קורות החיים 
//       </Typography>
//       <input type="file" onChange={handleFileChange} />
//       <Box className="upload-button-container">
//         <Button 
//           variant="contained" 
//           className="upload-button" 
//           onClick={handleUpload} 
//           disabled={loading}
//         >
//           {loading ? <CircularProgress size={24} color="inherit" /> : 'העלה קו"ח'}
//         </Button>
//       </Box>
//       {progress > 0 && <Typography>התקדמות: {progress}%</Typography>}
//       {message && <Typography color={message.includes('שגיאה') ? 'error' : 'success'}>{message}</Typography>}
//     </Box>
//   );
// };

// export default FileUpload;

import React, { useState } from 'react';
import { Button, CircularProgress, Typography, Box } from '@mui/material';
import RequestService from "../component/Services/RequestService"
import '../Style/FileUpload.css';

const FileUpload = () => {
  const [file, setFile] = useState<File | null>(null);
  const [progress, setProgress] = useState(0);
  const [loading, setLoading] = useState(false);
  const [message, setMessage] = useState<string>("");

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files) {
      setFile(e.target.files[0]);
      setMessage("");  // Reset message on new file selection
      setProgress(0);// Reset message on new file selection
    }
  };

  const handleUpload = async () => {
    if (!file) return;

    setLoading(true);
    setMessage("");

    try {
      const presignedUrl = await RequestService.getPresignedUrl(file.name, file.type);

      await RequestService.uploadFile(presignedUrl, file,setProgress);
      
      setMessage('הקובץ הועלה בהצלחה');
    } catch (error) {
      console.error('שגיאה בהעלאה', error);
      setMessage('שגיאה בהעלאה');
    } finally {
      setLoading(false);
    }
  };

  return (
    <Box className="file-upload-container">
      <Typography className="h1" variant="h4" gutterBottom>
        העלאת קורות החיים 
      </Typography>
      <input type="file" onChange={handleFileChange} />
      <Box className="upload-button-container">
        <Button 
          variant="contained" 
          className="upload-button" 
          onClick={handleUpload} 
          disabled={loading}
        >
          {loading ? <CircularProgress size={24} color="inherit" /> : 'העלה קו"ח'}
        </Button>
      </Box>
      {progress > 0 && <Typography>התקדמות: {progress}%</Typography>}
      {message && <Typography color={message.includes('שגיאה') ? 'error' : 'success'}>{message}</Typography>}
    </Box>
  );
};

export default FileUpload;
