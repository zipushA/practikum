import axios from 'axios';

const RequestService = {
  getPresignedUrl: async (fileName: string, contentType: string) => {
    const response = await axios.get('https://localhost:7082/api/Teacher/Upload-url', {
      params: { fileName, contentType }
    });
    return response.data.url;
  },

  uploadFile: async (url: string, file: File, setProgress: (progress: number) => void) => {
    await axios.put(url, file, {
      headers: {
        'Content-Type': file.type,
      },
      onUploadProgress: (progressEvent) => {
        const percent = Math.round(
          (progressEvent.loaded * 100) / (progressEvent.total || 1)
        );
        setProgress(percent); // עדכון אחוזי ההעלאה
      },
    });
  }
};

export default RequestService;

