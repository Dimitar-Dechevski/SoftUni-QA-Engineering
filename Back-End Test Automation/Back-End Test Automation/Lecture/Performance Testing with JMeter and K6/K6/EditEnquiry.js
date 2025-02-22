import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        {duration: '30s', target: 10},
        {duration: '1m', target: 10},
        {duration: '10s', target: 0}
    ]
};

export default function() {
    const enquiryID = '6760a1851d7e13e19346fdcc';

    const payload = JSON.stringify({
        name: 'Guest Guest',
        email: 'guest.guest@example.com',
        mobile: '0123456789',
        comment: 'Bug',
        status: 'Submitted'
    });

    const adminToken = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY3NjBhYTM4MTkwY2UxNGU1NzY1ZTI0NiIsImlhdCI6MTczNDM4ODMxNiwiZXhwIjoxNzM0NDc0NzE2fQ.aGOGrsNBNakDL42MWScO9xCDIBR-gaZ5pIDJoZBdcFU';

    const params = {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${adminToken}`
        }
    };

    const response = http.put(`http://localhost:5000/api/enquiry/${enquiryID}`, payload, params);

    check(response, {
        'status code is 200': (r) => r.status === 200,
        'body contains id and status fields': (r) => {
            const body = JSON.parse(r.body);
            return body.name === 'Guest Guest' && body.status === 'Submitted';
        }
    });
    
    sleep(1);
}