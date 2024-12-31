class BankAccount:
    def __init__(self, account_number, balance=0):
        self.account_number = account_number
        self.balance = balance

    def deposit(self, amount):
        if amount > 0:
            self.balance += amount
            print(f"{amount} so'm depozit qilindi. Joriy balans: {self.balance} so'm.")
        else:
            print("Depozit miqdori noldan katta bo'lishi kerak.")

    def withdraw(self, amount):
        if 0 < amount <= self.balance:
            self.balance -= amount
            print(f"{amount} so'm yechildi. Joriy balans: {self.balance} so'm.")
        else:
            print("Pul yechib olish uchun yetarli mablag' mavjud emas yoki miqdor noto'g'ri.")

    def get_balance(self):
        return self.balance


class Customer:
    def __init__(self, name, account):
        self.name = name
        self.account = account


class Bank:
    def __init__(self):
        self.customers = []

    def open_account(self, name, account_number, initial_deposit=0):
        account = BankAccount(account_number, initial_deposit)
        customer = Customer(name, account)
        self.customers.append(customer)
        print(f"Mijoz {name} uchun hisob raqami ochildi: {account_number}.")
        return account

    def close_account(self, account_number):
        for customer in self.customers:
            if customer.account.account_number == account_number:
                self.customers.remove(customer)
                print(f"Hisob raqami yopildi: {account_number}.")
                return
        print("Hisob raqami topilmadi.")

    def transfer(self, from_account_number, to_account_number, amount):
        from_account = None
        to_account = None

        for customer in self.customers:
            if customer.account.account_number == from_account_number:
                from_account = customer.account
            if customer.account.account_number == to_account_number:
                to_account = customer.account

        if from_account and to_account:
            if from_account.balance >= amount:
                from_account.withdraw(amount)
                to_account.deposit(amount)
                print(f"{amount} so'm {from_account_number} dan {to_account_number} ga o'tkazildi.")
            else:
                print("Pul o'tkazish uchun yetarli mablag' mavjud emas.")
        else:
            print("Hisob raqami topilmadi.")


class BankApp:
    def run(self):
        bank = Bank()

        # Mijozlar va hisoblar yaratish
        account1 = bank.open_account("Ali", "12345", 1000)
        account2 = bank.open_account("Vali", "67890", 500)

        # Hisoblar o'rtasida pul o'tkazish
        bank.transfer("12345", "67890", 300)

        # Balansni ko'rsatish
        print(f"Ali balans: {account1.get_balance()} so'm")
        print(f"Vali balans: {account2.get_balance()} so'm")

        # Hisob yopish
        bank.close_account("12345")

# Dastur ishga tushiriladi
if __name__ == "__main__":
    app = BankApp()
    app.run()

