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
    const response = http.get('http://localhost:5000/api/enquiry/67608652639560bcffed6fb7');

    check(response, {
        'status code is 200': (r) => r.status === 200,
        'body contains id and status fields': (r) => {
            const body = JSON.parse(r.body);
            return body.hasOwnProperty('_id') && body.hasOwnProperty('status');
        }
    });
    
    sleep(1);
}