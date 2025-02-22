import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        {duration: '1m', target: 10}
    ]
};

export default function() {
    const payload = JSON.stringify({
        name: 'Admin User',
        email: 'admin.user@example.com',
        mobile: '9876543210',
        comment: 'Test',
        status: 'In Progress'
    });

    const params = {
        headers: {
            'Content-Type': 'application/json'
        }
    };

    const response = http.post('http://localhost:5000/api/enquiry/', payload, params);

    check(response, {
        'status code is 200': (r) => r.status === 200,
        'body contains id and status fields': (r) => {
            const body = JSON.parse(r.body);
            return body.hasOwnProperty('_id') && body.hasOwnProperty('status');
        }
    });
    
    sleep(1);
}