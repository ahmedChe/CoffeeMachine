import { AbstractControl,ValidatorFn } from '@angular/forms';


export const passwordConfirming : ValidatorFn = (c: AbstractControl) => {
    return (c.get('password').value === c.get('confirm_password').value) ? null : {'mismatch': true};
};
