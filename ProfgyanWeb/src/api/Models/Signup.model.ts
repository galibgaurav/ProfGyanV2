export class signupModel {
  username: string;
  password: string;
  firstname: string;
  lastname: string;
  email: string;
  phone: string;
  ConfirmPassword: string = "";
  LoggedOn: string = "";
  become: string;
  roles: [string];

  constructor() { }
}
