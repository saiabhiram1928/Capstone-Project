import { Typography , Input, Button } from '@material-tailwind/react'
import React , {useState , useEffect} from 'react'
import LoginPage_Asset from '../Assets/Login_Page_Asset.png';


const Login_Page = () => {
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
const phoneRegex = /^\+?[1-9]\d{1,14}$/;
const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
const [emailOrPhone, setEmailOrPhone] = useState('');
const [password, setPassword] = useState('');
const [errors, setErrors] = useState({ emailOrPhone: '', password: '' });
const [isFormValid, setIsFormValid] = useState(false);
  const handleEmailOrPhoneNumber = (e)=>{
    const value = e.target.value;
    setEmailOrPhone(value);
    if (!emailRegex.test(value) && !phoneRegex.test(value)) {
        setErrors((prevErrors) => ({
            ...prevErrors,
            emailOrPhone: 'Invalid email or phone number format.',
        }));
    } else {
        setErrors((prevErrors) => ({
            ...prevErrors,
            emailOrPhone: '',
        }));
    }
  }
  const handlePassword = (e)=>{
    const value = e.target.value;
    setPassword(value);
    if (!passwordRegex.test(value)) {
        setErrors((prevErrors) => ({
            ...prevErrors,
            password: 'Password must be at least 8 characters long, include one uppercase letter, one lowercase letter, and one number.',
        }));
    } else {
        setErrors((prevErrors) => ({
            ...prevErrors,
            password: '',
        }));
    }
  }
  useEffect(() => {
    const isEmailOrPhoneValid = emailRegex.test(emailOrPhone) || phoneRegex.test(emailOrPhone);
    const isPasswordValid = passwordRegex.test(password);
    setIsFormValid(isEmailOrPhoneValid && isPasswordValid);
}, [emailOrPhone, password]);
  return (
    <div className="flex h-screen font-mono">
    {/* <!-- Left Pane --> */}
    <div className="hidden lg:flex items-center justify-center flex-1 bg-[#F7E7CE] text-black">
      <div className="max-w-md text-center h-full w-full">
        <img className='w-full h-full' src={LoginPage_Asset}/>
      </div>
    </div>
    {/* <!-- Right Pane --> */}
    <div className="w-full bg-gray-100 lg:w-1/2 flex items-center justify-center">
      <div className="max-w-md w-full p-6">
        <Typography variant = 'h2' className="font-bold font-mono mb-6 text-center">Login</Typography>
        <form  className="space-y-4">
          <div>
          <Input className='font-mono' type="text" value={emailOrPhone} onChange={handleEmailOrPhoneNumber} label="Email Or Phone" placeholder="Enter Your Email Or Phone Number"/>
          {errors.emailOrPhone && <Typography variant='paragraph' className="text-red-800 text-sm mt-2">  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="currentColor" className="size-4 inline mr-1">
  <path fillRule="evenodd" d="M6.701 2.25c.577-1 2.02-1 2.598 0l5.196 9a1.5 1.5 0 0 1-1.299 2.25H2.804a1.5 1.5 0 0 1-1.3-2.25l5.197-9ZM8 4a.75.75 0 0 1 .75.75v3a.75.75 0 1 1-1.5 0v-3A.75.75 0 0 1 8 4Zm0 8a1 1 0 1 0 0-2 1 1 0 0 0 0 2Z" clipRule="evenodd" />
</svg><span>{errors.emailOrPhone} </span> </Typography>}
          </div>
          <div>
           <Input onChange={handlePassword} value={password} type='password' label='password' placeholder='Enter Your Password'/>
           {errors.password && <Typography variant='paragraph' className="text-red-800 text-sm mt-2">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="currentColor" className="size-4 inline mr-1">
  <path fillRule="evenodd" d="M6.701 2.25c.577-1 2.02-1 2.598 0l5.196 9a1.5 1.5 0 0 1-1.299 2.25H2.804a1.5 1.5 0 0 1-1.3-2.25l5.197-9ZM8 4a.75.75 0 0 1 .75.75v3a.75.75 0 1 1-1.5 0v-3A.75.75 0 0 1 8 4Zm0 8a1 1 0 1 0 0-2 1 1 0 0 0 0 2Z" clipRule="evenodd" />
</svg><span>{errors.password} </span> </Typography>}
          </div>
          <div>
            <Button type="submit"  disabled = {!isFormValid} fullWidth>Sign Up</Button>
          </div>
        </form>
        <div className="mt-4 text-sm text-gray-600 text-center">
          <p>Already have an account? <a href="#" className="text-black hover:underline">Login here</a>
          </p>
        </div>
      </div>
    </div>
  </div>
  )
}

export default Login_Page