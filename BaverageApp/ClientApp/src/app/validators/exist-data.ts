import { AuthenticationService } from '../services/authentification.service';
import { FormControl } from '@angular/forms';
import { Observable} from 'rxjs';
import {map} from 'rxjs/operators';

export const existAsyncValidator = 
  (authService: AuthenticationService) => {
    return (input: FormControl) : Observable<{ [key: string]: any } | null> => {
        let formGroup = input.parent.controls;
        let name= Object.keys(formGroup).find(name => input === formGroup[name])
      return authService.existingMail(input.value,name)
      .pipe(
        map((isUsed:boolean) => {
        return !isUsed ? null : { 'exist': true };
    }));      
    };
  };