import axios from "axios";

export class ApiService {
    async GetShortenUrl(originalUrl: string): Promise<string> {
        try {
            const { data } = await axios.post("http://localhost:5120/short",
                {
                    fullUrl: originalUrl
                },
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            );
            return data.fullShortenUrl;
        } catch (err) {
            console.warn('Error shortening URL:', err);
            return ''; // Return an empty string or handle the error as needed
        }
    }
}
