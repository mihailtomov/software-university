class VeterinaryClinic {
    clients = [];

    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.totalProfit = 0;
        this.currentWorkload = 0;
    }

    newCustomer(ownerName, petName, kind, procedures) {
        let currentPatients = 0;

        this.clients.forEach(owner => {
            currentPatients += owner.pets.filter(p => p.procedures.length > 0).length;
        });

        if (currentPatients >= this.capacity) {
            throw new Error('Sorry, we are not able to accept more patients!');
        }

        let owner = this.clients.find(o => o.ownerName == ownerName);

        if (owner) {
            let hasPet = owner.pets.some(p => p.petName == petName);

            if (hasPet) {
                let pet = owner.pets.find(p => p.petName == petName);

                if (pet.procedures.length > 0) {
                    throw new Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${pet.procedures.join(', ')}.`);
                }
            }
        }

        let currentOwner = {
            ownerName,
            pets: [],
        }

        let currentPet = {
            petName,
            kind,
            procedures,
        }

        if (owner) {
            owner.pets.push(currentPet);
        } else {
            currentOwner.pets.push(currentPet);
            this.clients.push(currentOwner);
        }

        this.currentWorkload++;
        return `Welcome ${petName}!`;
    }

    onLeaving(ownerName, petName) {
        if (!this.clients.some(o => o.ownerName == ownerName)) {
            throw new Error('Sorry, there is no such client!');
        }

        let owner = this.clients.find(o => o.ownerName == ownerName);

        if (!owner.pets.some(p => p.petName == petName) ||
            ((owner.pets.some(p => p.petName == petName)) && (owner.pets.find(p => p.petName == petName).procedures.length == 0))) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }

        let pet = owner.pets.find(p => p.petName == petName);

        pet.procedures.forEach(p => {
            this.totalProfit += 500;
        });

        pet.procedures = [];
        this.currentWorkload--;

        return `Goodbye ${petName}. Stay safe!`;
    }

    toString() {
        let busyPercentage = 0;

        if (this.currentWorkload > 0) {
            busyPercentage = (this.currentWorkload / this.capacity) * 100;
        }
        
        let output = `${this.clinicName} is ${Math.floor(busyPercentage)}% busy today!\n`;
        output += `Total profit: ${this.totalProfit.toFixed(2)}$\n`;

        this.clients.sort((a, b) => a.ownerName.localeCompare(b.ownerName));

        this.clients.forEach(owner => {
            output += `${owner.ownerName} with:\n`;

            owner.pets
            .sort((a, b) => a.petName.localeCompare(b.petName))
            .forEach(pet => {
                output += `---${pet.petName} - a ${pet.kind.toLowerCase()} that needs: ${pet.procedures.join(', ')}\n`;
            });
        });

        return output.trim();
    }
}

let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Jim Jones', 'Jerry', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Jim Jones', 'merry', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Jim Jones', 'john', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.onLeaving('Jim Jones', 'merry'));
console.log(clinic.onLeaving('Jim Jones', 'john'));
console.log(clinic.toString());
