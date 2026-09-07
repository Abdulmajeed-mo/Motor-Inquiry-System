using Motor.Inquiry.Application.DTOs;

namespace Motor.Inquiry.Application.Interfaces;

public interface IAuthService
{
    LoginResponse? Login(LoginRequest request);
}