import subprocess
from sys import argv

from constants import PROJECT, STARTUP_PROJECT

def run(command: list[str]):
    subprocess.run(command)

def update():
    run([
        "dotnet", "ef", "database", "update",
        "--project", str(PROJECT),
        "--startup-project", str(STARTUP_PROJECT)
    ])

if __name__ == "__main__":
    action = argv[1]

    match action:
        case "update":
            update()
        case _:
            print("Comandos: update")