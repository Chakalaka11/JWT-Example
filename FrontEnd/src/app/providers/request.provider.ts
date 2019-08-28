import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { ApiConfiguration } from '../configurations/api.configuration';
import { TokenModel } from '../models/response.models';

@Injectable()
export class RequestProvider {
    constructor(
        private client: HttpClient,
        private headers: HttpHeaders) {
    }

    private initializeHeaders() {
        this.headers = this.headers.append("Authorization", "Bearer " + localStorage.getItem("jwtToken"));
    }

    public requestJwtToken(): Observable<TokenModel> {
        return this.client.get<TokenModel>(ApiConfiguration.Host + ApiConfiguration.GetJWTToken);
    }
}