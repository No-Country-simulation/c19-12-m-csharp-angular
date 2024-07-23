export interface User {
  userName: string;
  role: string;
}

export interface UserRegister {
  userName?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  email?: string | null;
  dni?: string | null;
  phoneNumber?: string | null;
  password?: string | null;
  address?: string | null;
}

export interface UserLogin {
  userName?: string | null;
  password?: string | null;
}
