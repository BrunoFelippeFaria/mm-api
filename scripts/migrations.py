import subprocess
from sys import argv

from constants import PROJECT, STARTUP_PROJECT

def run(command: list[str]):
    subprocess.run(command)

def add(name: str):
    if (name == ''):
        print('nome não pode ser vazio')
        exit(1)

    run([
        "dotnet", "ef", "migrations", "add", name,
        "--project", str(PROJECT),
        "--startup-project", str(STARTUP_PROJECT)
    ])

def remove():
    run([
        "dotnet", "ef", "migrations", "remove",
        "--project", str(PROJECT),
        "--startup-project", str(STARTUP_PROJECT)
    ])

if __name__ == "__main__":
    action = argv[1]

    match action:
        case "add":
            add(argv[2])
        case "remove":
            remove()
        case _:
            print("Comandos: add <nome> | remove")