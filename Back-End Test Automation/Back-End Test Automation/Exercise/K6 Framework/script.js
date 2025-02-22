import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    /*ext: {
        loadimpact: {
            projectID: '3727360'
        }
    },*/
    vus: 10,
    duration: '10s'
};

export default function () {
    http.get('https://test.k6.io');
    sleep(1);
}