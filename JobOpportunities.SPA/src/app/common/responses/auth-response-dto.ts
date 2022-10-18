export interface AuthResponseDto {
  isAuthSuccessful: boolean;
  refreshToken: string;
  accessToken: string;
}
