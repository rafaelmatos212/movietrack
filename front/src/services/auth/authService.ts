import { apiFetch } from "../api";
import { LoginRequest, LoginResponse, RegisterRequest, RegisterResponse } from "./types";

export async function login(request: LoginRequest): Promise<LoginResponse> {
    console.log("SAASDS")
    return await apiFetch<LoginResponse>('/api/account/login', {
        method: 'POST',
        body: JSON.stringify(request)
    })
}

export async function register(request: RegisterRequest): Promise<RegisterResponse> {
    return await apiFetch<RegisterResponse>('/api/account/register', {
        method: 'POST',
        body: JSON.stringify(request)
    })
}