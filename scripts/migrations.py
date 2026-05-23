import subprocess
from sys import argv

from constants import MM_INFRASTRUCTURE, MM_API

def run(command: list[str]):
    subprocess.run(command)

def add(name: str):
    if (name == ''):
        print('nome não pode ser vazio')
        exit(1)

    run([
        "dotnet", "ef", "migrations", "add", name,
        "--project", str(MM_INFRASTRUCTURE),
        "--startup-project", str(MM_API)
    ])

def remove():
    run([
        "dotnet", "ef", "migrations", "remove",
        "--project", str(MM_INFRASTRUCTURE),
        "--startup-project", str(MM_API)
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