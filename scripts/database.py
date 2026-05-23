import subprocess
from sys import argv

from constants import MM_INFRASTRUCTURE, MM_API

def run(command: list[str]):
    subprocess.run(command)

def update():
    run([
        "dotnet", "ef", "database", "update",
        "--project", str(MM_INFRASTRUCTURE),
        "--startup-project", str(MM_API)
    ])

if __name__ == "__main__":
    action = argv[1]

    match action:
        case "update":
            update()
        case _:
            print("Comandos: update")