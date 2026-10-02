const API_URL = process.env.NEXT_PUBLIC_API_URL;

export class ApiError extends Error {
	constructor(
		public status: number,
		public title: string,
		message: string,
	) {
		super(message);
		this.name = 'ApiError';
	}
}

export async function apiFetch<TResponse>(
	path: string,
	options: RequestInit = {},
): Promise<TResponse> {
	const response = await fetch(`${API_URL}${path}`, {
		...options,
		headers: {
			'Content-Type': 'application/json',
			...options.headers,
		},
	})

	if (!response.ok) {
		const error = await response.json().catch(() => null)
		throw new ApiError(
			response.status,
			error?.title || 'Error',
			error?.detail ?? "An unknown error occurred"
		)
	}

	return response.json() as Promise<TResponse>
}