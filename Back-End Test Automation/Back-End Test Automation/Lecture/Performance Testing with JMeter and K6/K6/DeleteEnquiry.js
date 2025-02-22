import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        {duration: '1m', target: 10}
    ]
};

export default function() {
    const adminToken = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY3NjBhYTM4MTkwY2UxNGU1NzY1ZTI0NiIsImlhdCI6MTczNDM4ODMxNiwiZXhwIjoxNzM0NDc0NzE2fQ.aGOGrsNBNakDL42MWScO9xCDIBR-gaZ5pIDJoZBdcFU';

    const params = {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${adminToken}`
        }
    };

    const allEnquiriesResponse = http.get('http://localhost:5000/api/enquiry/');
    const allEnquiries = JSON.parse(allEnquiriesResponse.body);

    allEnquiries.forEach((enquiry) => {
        if (enquiry.name == 'Admin User') {
            const response = http.del(`http://localhost:5000/api/enquiry/${enquiry._id}`, null, params);

            check(response, {
                'status code is 200': (r) => r.status === 200
            })
        }
    }); 

    sleep(1);
}